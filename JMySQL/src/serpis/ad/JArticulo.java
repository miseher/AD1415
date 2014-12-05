package serpis.ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.*;



public class JArticulo {

	public static void main(String[] args) throws ClassNotFoundException, SQLException {
	     int opc;
		Connection connection = DriverManager.getConnection(
                "jdbc:mysql://localhost/dbprueba?user=root&password=sistemas");
		
		
		System.out.println("Elige una opcion: ");
		System.out.println("");
		
		System.out.println("0-SALIR");
		System.out.println("1-NUEVO");
		System.out.println("2-EDITAR");
		System.out.println("3-ELIMINAR");
		System.out.println("4-VISUALIZAR");
		
		
		Scanner sc=new Scanner(System.in);
		opc= sc.nextInt();
		
		switch(opc){
		
			case 0:
				System.out.println("Saliendo...");
				System.exit(0);
				break;
				
			case 1:
				
				
			case 2:
				
			
				
			case 3:
				
				
				
				
			case 4:	
				Statement statement = connection.createStatement();
		        ResultSet resultSet = statement.executeQuery("SELECT * FROM categoria");
		        
		        resultSet.close();
		        break;
		
		}
		
		
	}
	
}
