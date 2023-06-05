using Lab5Library.Composite;
using Lab5Library.Composite2;
using Lab5Library.Proxy;
using System.Text.RegularExpressions;
using System.Xml.Linq;

Console.WriteLine("1. Composite\n2. Composite2\n3. Proxy\n4. Flyweight");
int choiseTask = Int32.Parse(Console.ReadLine());

switch (choiseTask)
{
    case 1:
        var html = new LightElementNode("html");

        var head = new LightElementNode("head");
        html.AppendChild(head);

        var title = new LightElementNode("title");
        head.AppendChild(title);
        var titleText = new LightTextNode("LightHTML Example");
        title.AppendChild(titleText);

        var body = new LightElementNode("body");
        html.AppendChild(body);

        var header = new LightElementNode("h1");
        body.AppendChild(header);
        var headerText = new LightTextNode("Hello, world!");
        header.AppendChild(headerText);

        var list = new LightElementNode("ul");
        body.AppendChild(list);

        var listItem1 = new LightElementNode("li");
        var listItem2 = new LightElementNode("li");
        list.AppendChild(listItem1);
        list.AppendChild(listItem2);
        var listItem1Text = new LightTextNode("Item 1");
        var listItem2Text = new LightTextNode("Item 2");
        listItem1.AppendChild(listItem1Text);
        listItem2.AppendChild(listItem2Text);


        html.Print();
        break;
    case 2:
        var mainHero = new MarvelHero("Black Pantera", 10);
        var ironMan = new MarvelHero("IronMan", 5000);

        var gloveOfPower = new CompositeArtefact("GloveOfPower", 10, 5000);
        var infinityStones = Enumerable.Range(1, 5).Select(i => new Artefact($"InfinityStone{i}", 2, 1000)).ToList();

        for (int i = 0; i < infinityStones.Count; i++)
        {
            gloveOfPower.AddArtefact(infinityStones[i]);
        }
        
        ironMan.artefacts.AddArtefact(gloveOfPower);
        mainHero.AddFriend(ironMan);

        mainHero.CountArtefacts();
        mainHero.CalculateArtefactsWeight();
        mainHero.Strike();

        Console.WriteLine("Removing Glove of Power from IronMan");
        ironMan.artefacts.RemoveArtefact(gloveOfPower);

        mainHero.CountArtefacts();
        mainHero.CalculateArtefactsWeight();
        mainHero.Strike();


        break;
    case 3:
        ITextReader smartTextReader = new SmartTextReader();
        smartTextReader = new SmartTextChecker(smartTextReader);
        smartTextReader = new SmartTextReaderLocker(smartTextReader, new Regex(@"^restricted.*"));

        char[][] result1 = smartTextReader.ReadFile("test.txt");
        char[][] result2 = smartTextReader.ReadFile("restricted.txt"); 

        Console.ReadKey();

        break;
    case 4:
        string text = File.ReadAllText("book.txt");

        var lines = text.Split('\n');

        var htmlTree = new LightElementNode("html");

        var bodyElement = new LightElementNode("body");


        for (int i = 0; i < lines.Length; i++)
        {
            if(i == 0)
            {
                var h1 = new LightElementNode("h1") { Children = { new LightTextNode(lines[i].TrimEnd()) } };
                bodyElement.AppendChild(h1);
            }
            var node = CreateNodeFromText(lines[i].TrimEnd());
            bodyElement.AppendChild(node);
        }

        htmlTree.AppendChild(bodyElement);
        htmlTree.Print();

        long totalSize = GC.GetTotalMemory(false);

        Console.WriteLine($"Total size: {totalSize} bytes");

        break;
    default:
        break;
}
static LightNode CreateNodeFromText(string text)
{
    if (string.IsNullOrWhiteSpace(text))
    {
        return new LightTextNode("");
    }

    if (text.Length < 20)
    {
        return new LightElementNode("h2") { Children = { new LightTextNode(text) } };
    }

    if (char.IsWhiteSpace(text[0]))
    {
        return new LightElementNode("blockquote") { Children = { new LightTextNode(text.TrimStart()) } };
    }

    return new LightElementNode("p") { Children = { new LightTextNode(text) } };
}