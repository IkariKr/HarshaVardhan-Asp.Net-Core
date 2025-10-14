namespace ViewExample.Models;

//为了解决Model只能绑定一个模型，所以创建一个包装模型
public class PersonAndProductWarpperModel
{
    public Person PersonData { get; set; }
    public Product ProductData { get; set; }
}