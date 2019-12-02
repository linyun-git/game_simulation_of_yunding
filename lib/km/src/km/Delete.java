package km;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;

import org.dom4j.Document;
import org.dom4j.DocumentException;
import org.dom4j.Element;
import org.dom4j.io.OutputFormat;
import org.dom4j.io.SAXReader;
import org.dom4j.io.XMLWriter;

public class Delete {
	public static void delete(int i, String name) throws DocumentException, IOException{
		
        SAXReader reader = new SAXReader();    //创建一个dom4j解析器
        Document document = reader.read(new File("src/12345.xml"));  //加载document对象
        Element root = document.getRootElement();  //获取根节点
        
        i=i-1;
        Element good = (Element)root.elements("good").get(i);  //获得第i个good节点
        Element omit = good.element(name);
        omit.getParent().remove(omit);  //通过需要被删除的节点的父节点来将其删除
        
        //下面是将结果保存
        XMLWriter writer = new XMLWriter(new FileOutputStream("src/12345.xml"),OutputFormat.createPrettyPrint());
        writer.write(document);
        writer.close();
        
        i+=1;
        System.out.println("成功将第"+ i +"个good节点中的名为"+name+"的子节点删除！");
	}

}
