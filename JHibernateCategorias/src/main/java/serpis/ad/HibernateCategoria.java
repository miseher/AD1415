package serpis.ad;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class HibernateCategoria {
	private static EntityManagerFactory entityManagerFactory;  
	public static void main(String[] args) {
	
				entityManagerFactory= Persistence.createEntityManagerFactory("serpis.ad.jpa.mysql");
				
				ShowCategorias();
				System.out.println("Añado categorias");
				
				persistNuevasCategorias();
				ShowCategorias();
				removeCategoria((long) 1);
				
				
		entityManagerFactory.close();

	}

	public static void persistNuevasCategorias(){
		EntityManager entityManager=entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		
		Categoria categoria=new Categoria();
		categoria.setNombre("Hibernate "+ new SimpleDateFormat("yyyy-MM-dd HH:mm:ss").format(new Date()));
		entityManager.persist(categoria);
	
		
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	
	public static void ShowCategorias(){
		EntityManager entityManager=entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		List<Categoria> categorias=entityManager.createQuery("from Categoria", Categoria.class).getResultList();
		for (Categoria categoria: categorias)
			System.out.printf("id=%d nombre=%s\n", categoria.getId(),categoria.getNombre());
		
		
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	
	
	//BORRAR
	public static void removeCategoria(Long id){
		EntityManager entityManager=entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		entityManager.remove(entityManager.find(Categoria.class, 1)); //object primary key

		entityManager.getTransaction().commit();
		entityManager.close();
	}
	//editar
	
	
	public static void editCategoria(Long id){
		EntityManager entityManager=entityManagerFactory.createEntityManager();
		Categoria categoria=entityManager.find(Categoria.class, 1);
		categoria.setNombre("nombre editado");
		entityManager.getTransaction().begin();
		
		entityManager.merge(categoria);

		entityManager.getTransaction().commit();
		entityManager.close();
	}
	
}
