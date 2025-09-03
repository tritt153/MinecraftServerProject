using MinecraftServer.Models.Common.JsonMessages;
using MinecraftServer.Models.Common.Utilities.Extension_Methods;
using System.Windows;
using static MinecraftServer.Models.Common.Json_Messages.Constants.JsonTextColor;

namespace MinecraftServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //JsonMessage oTest = "Hello".Color(eTextColor.Aqua).Italicize().Bold().Obfuscate().Strikethrough().Underline() + "World".Bold();

            InitializeComponent();
        }
    }
}