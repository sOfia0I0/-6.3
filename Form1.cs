// Пространство имен для взаимодействия с БД с помощью Entity Framework Core
using Microsoft.EntityFrameworkCore;
namespace пр6._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Класс User, определяющий структуру объекта User со свойствами Id, Familiya, Imya, Login, Parol, Kodovoeslovo
        public class User
        {
            public int Id { get; set; }
            public string Familiya { get; set; }
            public string Imya { get; set; }
            public string Login { get; set; }
            public string Parol { get; set; }
            public string Kodovoeslovo { get; set; }
        }
        // Обработчик нажатия кнопки
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string familiya = textBox1.Text;
                string imya = textBox2.Text;
                string login = textBox3.Text;
                string parol = textBox4.Text;
                string kodovoeslovo = textBox5.Text;
                // Добавление пользователей в БД
                using (ApplicationContext db = new ApplicationContext())
                {
                    User user = new User
                    {
                        Familiya = familiya,
                        Imya = imya,
                        Login = login,
                        Parol = parol,
                        Kodovoeslovo = kodovoeslovo
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("Пользователь успешно сохранен!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении пользователя: " + ex.Message);
            }
        }
        // Класс, предоставляющий контекст для взаимодействия с БД
        public class ApplicationContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                string connectionString = "Server=localhost;Database=UserDatabase;Uid=root;Pwd=cDta5hdh56yupo;";
                optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 25)));
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
        }
    }
}
