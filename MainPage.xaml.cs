using Module05Exercise01.Services;
using MySql.Data.MySqlClient;

namespace Module05Exercise01
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private readonly DatabaseConnectionServices _dbConnectionService;

        public MainPage()
        {
            InitializeComponent();

            //Initialize database connection
            _dbConnectionService = new DatabaseConnectionServices();
        }

        private async void OnTestConnectionClicked(object sender, EventArgs args)
        {
            var connectionString = _dbConnectionService.GetConnectionString();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    ConnectionStatusLabel.Text = "Connection Successful!";
                    ConnectionStatusLabel.TextColor = Colors.Green;
                }
            }
            catch (Exception ex)
            {
                ConnectionStatusLabel.Text = $"Connection Failed!: {ex.Message}";
                ConnectionStatusLabel.TextColor = Colors.Red;
            }
        }

        private async void OpenViewEmployee(object sender, EventArgs args)
        {
            await Shell.Current.GoToAsync("//ViewEmployee");
        }
    }
}
