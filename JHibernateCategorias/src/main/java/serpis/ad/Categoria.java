package serpis.ad;

import java.util.Date;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;

import org.hibernate.annotations.GenericGenerator;

import javax.persistence.Id;

@Entity 
public class Categoria {
    private Long id;
    private String nombre;
	
public Categoria(){}    
  
    
@Id    
@GeneratedValue(generator="increment")
@GenericGenerator(name="increment", strategy = "increment")
    public Long getId() {
		return id;
    }

    private void setId(Long id) {
		this.id = id;
    }
	
  

      public String getNombre() {
  		return nombre;
      }

      public void setNombre(String nombre) {
  		this.nombre = nombre;
      } 
    
    
}
