package km;
import java.io.File;
import java.util.List;


import org.dom4j.Document;
import org.dom4j.DocumentException;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;

public class Query {

	public static void query_only(int i , String str ) throws DocumentException {
        SAXReader reader = new SAXReader();    //����һ��dom4j������
        Document document = reader.read(new File("src/12345.xml"));  //����document����
        Element root = document.getRootElement();  //��ȡ���ڵ�
    
    
        List<Element> list = root.elements("good");  //������е�good�ڵ�
        i=i-1;
        Element good = list.get(i);   //����˵�i��good
        System.out.println(good.elementText(str));    //�����i��good�������ѯ��ֵ
	}
	
	public static void query_all(String str) throws DocumentException {
        SAXReader reader = new SAXReader();    //����һ��dom4j������
        Document document = reader.read(new File("src/12345.xml"));  //����document����
        Element root = document.getRootElement();  //��ȡ���ڵ�
        List<Element> list = root.elements("good");  //������е�good�ڵ�

        for (Element good : list) {
        	Element out = good.element(str);
        	String string = out.getText();
        	System.out.println(string);  
        }


	}
    
}
