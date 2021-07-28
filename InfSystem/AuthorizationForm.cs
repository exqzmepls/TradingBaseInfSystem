using DbConnection;
using System.Windows.Forms;

namespace InfSystem
{
    public partial class AuthorizationForm : Form
    {
        private readonly string _errorMessage = "Не удаётся войти. Пожалуйста, проверьте правильность написания логина и пароля.";

        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void AuthorizationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (int.TryParse(loginTextBox.Text, out int id) && LogIn(id, passwordTextBox.Text) is User user)
                {
                    MainForm.user = user;
                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show(_errorMessage);
                    loginTextBox.Focus();
                }
            }
        }

        private User LogIn(int login, string password)
        {
            string _password = "123qwe";
            if (login == 0 && password == _password)
            {
                return new SuperUser(login);
            }

            try
            {
                using (InfSystemContext db = new InfSystemContext())
                {
                    Employee employee = db.Employees.Find(login);
                    if (employee == null) return null;
                    db.Entry(employee).Reference(x => x.Person).Load();
                    if (employee.Person.PhoneNumber == password)
                    {
                        switch ((PositionId)employee.PositionId)
                        {
                            case PositionId.ADMIN:
                                return new SuperUser(login);
                            case PositionId.SENIOR_ASSISTANT:
                                return new FavoredUser(login);
                            case PositionId.ASSISTANT:
                                return new User(login);
                            default:
                                return null;
                        }
                    }
                    else return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
