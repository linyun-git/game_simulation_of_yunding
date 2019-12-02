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

public class Alter {

	public static void alter(int i, String name, String content) throws DocumentException, IOException{
		
        SAXReader reader = new SAXReader();    //����һ��dom4j������
        Document document = reader.read(new File("src/12345.xml"));  //����document����
        Element root = document.getRootElement();  //��ȡ���ڵ�
        
        i=i-1;
        Element good = (Element)root.elements("good").get(i);  //��õ�i��good�ڵ�
        Element change = good.element(name);  //��������޸ĵĽڵ�
        change.setText(content);
        
        //�����ǽ��������
        XMLWriter writer = new XMLWriter(new FileOutputStream("src/12345.xml"),OutputFormat.createPrettyPrint());
        writer.write(document);
        writer.close();
        
        i+=1;
        System.out.println("�ɹ�����"+ i +"��good�ڵ��"+name+"�ӽڵ�������޸�ΪΪ"+content);
	}
        
}
