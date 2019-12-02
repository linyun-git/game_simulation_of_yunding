package km;
import java.io.File;
import java.util.List;


import org.dom4j.Document;
import org.dom4j.DocumentException;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;

public class Query {

	public static void query_only(int i , String str ) throws DocumentException {
        SAXReader reader = new SAXReader();    //创建一个dom4j解析器
        Document document = reader.read(new File("src/12345.xml"));  //加载document对象
        Element root = document.getRootElement();  //获取根节点
    
    
        List<Element> list = root.elements("good");  //获得所有的good节点
        i=i-1;
        Element good = list.get(i);   //获得了第i个good
        System.out.println(good.elementText(str));    //输出第i个good的所需查询的值
	}
	
	public static void query_all(String str) throws DocumentException {
        SAXReader reader = new SAXReader();    //创建一个dom4j解析器
        Document document = reader.read(new File("src/12345.xml"));  //加载document对象
        Element root = document.getRootElement();  //获取根节点
        List<Element> list = root.elements("good");  //获得所有的good节点

        for (Element good : list) {
        	Element out = good.element(str);
        	String string = out.getText();
        	System.out.println(string);  
        }


	}
    
}
