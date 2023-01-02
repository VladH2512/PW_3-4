using PW_3_4.Database;
using System;

namespace PW_3_4
{
    

    class Program
    {
        static void Main(string[] args)
        {
            string select;
            Datebase.GetInstance();

            Entity entity = new Entity();
            EntityFactory factory = new EntityFactory();

            do
            {

                Console.WriteLine("[Программа по сохранению и управлению данными мобильных телефонов]\n");

                Console.WriteLine("1) Директора");
                Console.WriteLine("2) Компании");
                Console.WriteLine("3) Телефоны");
                Console.WriteLine("4) Сети");

                if (entity.CheckObserver(factory))
                    Console.WriteLine("5) Включить(+) оповещения");
                else
                    Console.WriteLine("5) Выключить(-) оповещения");

                Console.WriteLine("0) Выйти");
                Console.Write("Выберит номер: ");

                select = Console.ReadLine();
                entity.SetEntityDAO(factory.CreateEntity(select));

                if (entity.GetEntityDAO() != null)
                    MenuTable(entity.GetEntityDAO());

                // Добавление/Удаление подписки
                else if (select == "5")
                    if (entity.CheckObserver(factory))
                        entity.AddObserver(factory);
                    else
                        entity.RemoveObserver(factory);

                Console.Clear();

            } while (select != "0");
        }

        public static void MenuTable(EntityDAO entity)
        {
            string select;
            string table = entity.GetType().Name.Replace("DAO", "");

            do
            {
                Console.Clear();
                Console.WriteLine("[Программа по сохранению и управлению данными мобильных телефонов]\n");

                Console.WriteLine($"[{table}]");
                Console.WriteLine("1) Добавить");
                Console.WriteLine("2) Изменить(id)");
                Console.WriteLine("3) Удалить(id)");
                Console.WriteLine("4) Найти(id)");
                Console.WriteLine("5) Получить список");
                Console.WriteLine("0) Вернуться");
                Console.Write("Выберит номер: ");
                select = Console.ReadLine();

                Console.Clear();


                switch (select)
                {
                    case "1":
                        entity.Add();
                        entity.Operations("Add");
                        break;

                    case "2":
                        entity.Change();
                        entity.Operations("Change");
                        break;

                    case "3":
                        entity.Remove();
                        entity.Operations("Remove");
                        break;

                    case "4":
                        entity.Find();
                        break;

                    case "5":
                        entity.GetList();
                        break;

                    case "0":
                        break;

                    default:
                        Console.WriteLine($"Номера({select}) не существует!");
                        break;
                }

                Console.ReadKey();
            } while (select != "0");


        }
    }

}

