package serpis.ad;

import java.util.Date;

import javax.persistence.GeneratedValue;

import org.hibernate.annotations.GenericGenerator;

import javax.persistence.Id;

public class Categoria {
    private Long id;
    private String nombre;
	
    
    public Long getId() {
		return id;
    }

    private void setId(Long id) {
		this.id = id;
    }
	
    public void setDate(Date date) {
  		this.date = date;
      }

      public String getTitle() {
  		return title;
      }

      public void setTitle(String title) {
  		this.title = title;
      } 
    
    
}
