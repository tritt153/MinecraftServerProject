using MinecraftServer.Models.Common.JSON.Events;
using MinecraftServer.Models.Common.JSON.Messages;
using MinecraftServer.Models.Common.JSON.Utilities.Extension_Methods;
using System.Windows;
using static MinecraftServer.Models.Common.JSON.Utilities.JsonTextColor;

namespace MinecraftServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string sName = "Test";

            JsonMessage oTest = "One"
                                    .Color(eTextColor.Aqua)
                                    .Italicize()
                                    .Bold()
                                    .Obfuscate()
                                    .Strikethrough()
                                    .Underline()
                                    .NewLine(3)
                              + "Two"
                                    .Color(eTextColor.Red)
                              + "Three"
                                    .Color(eTextColor.Gray)
                              + sName
                                    .Color(eTextColor.Black)
                                    .Obfuscate()
                                    .HoverEvent(JsonHoverEvent.ShowText("Click for help".Text()))
                                    .ClickEvent(JsonClickEvent.RunCommand("/help"))
                              + "Magic"
                              + "Magic2";

            string sTest = oTest.ToString();

            JsonMessage oTest2 = "Test".ClickEvent(JsonClickEvent.RunCommand("/help"));

            string sTest2 = oTest2.ToString();  

            InitializeComponent();
        }
    }
}