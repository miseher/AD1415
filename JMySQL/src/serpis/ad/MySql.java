package serpis.ad;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;



public class MySql {

public static void main(String[] args) throws ClassNotFoundException, SQLException {
        
        //Class.forName("com.mysql.jdbc.Driver");  Necesario en tipo 3 o anterior
        //System.out.println("Hola MySql desde eclipse");
        Connection connection = DriverManager.getConnection(
                "jdbc:mysql://localhost/dbprueba?user=root&password=sistemas");
        //Statement statement = connection.createStatement();
        //ResultSet resultSet = statement.executeQuery("SELECT * FROM categoria");
        
        PreparedStatement preparedStatement = connection.prepareStatement(
                "select * from categoria where id = ?");
        preparedStatement.setObject(1, 1);
        ResultSet resultSet = preparedStatement.executeQuery();
        
        
        while(resultSet.next()){
            System.out.printf("id=%4s    nombre=%s\n", resultSet.getObject("id"), resultSet.getObject("nombre"));
        }
        
        //Cierro resultset, statement y connection
        resultSet.close();
        //statement.close();
        preparedStatement.close();
        connection.close();
    }

	
	
	
	
	
	
}
