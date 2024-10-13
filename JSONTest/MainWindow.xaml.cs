using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JSONTest
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                TypeInfoResolver = new PrivateConstructorContractResolver()
                
            };
            var z = new ModelItem(new Min()) { UIId ="mIN"};
            var q = JsonSerializer.Serialize(z);
            var d = JsonSerializer.Deserialize<ModelItem>(q,options);

            Console.WriteLine(q);
            Console.WriteLine(d);

        }

        public class PrivateConstructorContractResolver : DefaultJsonTypeInfoResolver
        {
            public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
            {
                JsonTypeInfo jsonTypeInfo = base.GetTypeInfo(type, options);

                if (jsonTypeInfo.Kind == JsonTypeInfoKind.Object && jsonTypeInfo.CreateObject is null)
                {
                    if (jsonTypeInfo.Type.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Length == 0)
                    {
                        // The type doesn't have public constructors
                        jsonTypeInfo.CreateObject = () =>
                            Activator.CreateInstance(jsonTypeInfo.Type, true);
                    }
                }

                return jsonTypeInfo;
            }
        }
    }
}
