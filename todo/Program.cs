using todo.Models;

List<Todolist> todoList = new List<Todolist>();
string select;
int _id;
string _title;
string _isComplated;

atpbContext db = new atpbContext();

while (true)
{
    Console.WriteLine("Yapmak istegiğiniz işlem: \n[0] Çıkış \n[1] Listele \n[2] Ekle \n[3] Düzenle \n[4] Sil");
    select = Console.ReadLine()!;
    switch (select)
    {
        case "0":
            cikis();
            break;
        case "1":
            listele(todoList);
            continue;

        case "2":
            ekle(todoList);
            continue;

        case "3":
            düzenle();
            continue;

        case "4":
            sil(todoList);
            continue;

        default:
            Console.WriteLine("0-4 arasında bir değer giriniz");
            continue;
    }
}
void cikis()
{
    Console.WriteLine("Güle Güle...");
    Environment.Exit(0);
}
void düzenle()
{
    Console.Write("Satır id:");
    _id = int.Parse(Console.ReadLine()!);
    Todolist t = db.Todolists.FirstOrDefault(x => x.Id == _id)!;
    Console.Write("Yeni başlık giriniz :");
    _title = Console.ReadLine()!;
    Console.Write("Görev tamamlandı mı? (E/H)");
    _isComplated = Console.ReadLine()!.ToUpper();
    if (t != null)
    {
        if (_isComplated == "E")
        {
            t.IsComplated = 1;
        }
        else if (_isComplated == "H")
        {
            t.IsComplated = 0;
        }
        t.Title = _title;
        Console.WriteLine("Kaydınız Başarıyla Değiştirildi");
    }
    else
    {
        Console.WriteLine("Düzenlemek istediğiniz id'e ait bilgiler bulunamadı");
    }

    db.SaveChanges();
}
void sil(List<Todolist> todoList)
{
    Console.Write("Satır id:");
    _id = int.Parse(Console.ReadLine()!);
    Todolist t = db.Todolists.FirstOrDefault(x => x.Id == _id)!;
    db.Todolists.Remove(t);
    db.SaveChanges();
    Console.WriteLine("Kaydınız Başarıyla Silindi");
}
void ekle(List<Todolist> todoList)
{
    Console.Write("Başlık :");
    _title = Console.ReadLine()!;
    Todolist t = new Todolist();
    t.Title = _title;
    t.IsComplated = 0;
    db.Todolists.Add(t);
    db.SaveChanges();
    Console.WriteLine("Kaydınız başarıyla eklendi!");
}

void listele(List<Todolist> todoList)
{
    var Todos = db.Todolists.ToList();
    Console.WriteLine("ID\tBaşlık\t\tDurum");

    foreach (var item in Todos)
    {
        if (item.IsComplated == 0)
        {
            Console.WriteLine($"{item.Id}\t{item.Title}\t\tfalse");
        }
        else
        {
            Console.WriteLine($"{item.Id}\t{item.Title}\t\ttrue");
        }
    }
}