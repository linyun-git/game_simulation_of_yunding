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

public class Increase {
	public static void increase_childNode(int i, String name, String content) throws DocumentException, IOException{
		
        SAXReader reader = new SAXReader();    //����һ��dom4j������
        Document document = reader.read(new File("src/12345.xml"));  //����document����
        Element root = document.getRootElement();  //��ȡ���ڵ�
        
        i=i-1;
        Element good = (Element)root.elements("good").get(i);  //��õ�i��good�ڵ�
        good.addElement(name).setText(content);  //���һ���ӽڵ� name,�����ֵΪ content
        
        //�����ǽ��������
        XMLWriter writer = new XMLWriter(new FileOutputStream("src/12345.xml"),OutputFormat.createPrettyPrint());
        writer.write(document);
        writer.close();
        
        i+=1;
        System.out.println("�ɹ����"+ i +"��good�ڵ������һ����Ϊ"+name+"���ӽڵ㣡������Ϊ"+content);
		
	}

}
