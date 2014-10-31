using System;
using Gtk;
using SerpisAd;
using PArticuloEjer;
using System.Data;

public partial class MainWindow: Gtk.Window
{	
	private IDbConnection dbConnection;
	private ListStore listStore;
	private ListStore listStore2;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		deleteAction.Sensitive = false;
		editAction.Sensitive = false;

		deleteAction1.Sensitive = false;
		editAction1.Sensitive = false;


		dbConnection = App.Instance.DbConnection;
		//Ventana articulo
		treeView.AppendColumn ("id", new CellRendererText (), "text", 0);
		treeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		treeView.AppendColumn ("categoria", new CellRendererText (), "text", 2);
		treeView.AppendColumn ("precio", new CellRendererText (), "text", 3);

		listStore = new ListStore (typeof(ulong), typeof(string), typeof(string), typeof(string));
		treeView.Model = listStore;

		fillListStore ();
		treeView.Selection.Changed += selectionChanged;

		//Ventana categoria
		treeView1.AppendColumn ("id", new CellRendererText (), "text", 0);
		treeView1.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		treeView1.AppendColumn ("categoria", new CellRendererText (), "text", 2);

		listStore2 = new ListStore (typeof(ulong), typeof(string), typeof(string));
		treeView1.Model = listStore2;

		fillListStore2 ();
		treeView1.Selection.Changed += selectionChanged;
	}

	private void selectionChanged (object sender, EventArgs e) {
		Console.WriteLine ("selectionChanged");
		bool hasSelected = treeView.Selection.CountSelectedRows () > 0;
		deleteAction.Sensitive = hasSelected;
		editAction.Sensitive = hasSelected;
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnQuitActionActivated (object sender, EventArgs e)
	{
		Application.Quit ();
	}
	private void fillListStore() {
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = "select * from categoria";

		IDataReader dataReader = dbCommand.ExecuteReader ();
		while (dataReader.Read()) {
			object id = dataReader ["id"];
			object nombre = dataReader ["nombre"];
			object cat = dataReader ["categoria"];
			object precio = dataReader ["precio"].ToString();
			listStore.AppendValues (id, nombre, cat, precio);
		}
		dataReader.Close ();
	}

	private void fillListStore2() {
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = "select * from categoria";

		IDataReader dataReader = dbCommand.ExecuteReader ();
		while (dataReader.Read()) {
			object id = dataReader ["id"];
			object cat = dataReader ["categoria"];
			object nombre = dataReader ["nombre"];
			listStore2.AppendValues (id, nombre, cat);
		}
		dataReader.Close ();
	}

	protected void OnDeleteActionActivated (object sender, EventArgs e)
	{
			MessageDialog messageDialog = new MessageDialog (
				this,
				DialogFlags.Modal,
				MessageType.Question,
				ButtonsType.YesNo,
				"¿Quieres eliminar el registro?"
				);
			messageDialog.Title = Title;
			ResponseType response = (ResponseType) messageDialog.Run ();
		messageDialog.Destroy ();

			if (response != ResponseType.Yes)
				return;

			TreeIter treeIter;
			treeView.Selection.GetSelected (out treeIter);
			object id = listStore.GetValue (treeIter, 0);
			string deleteSql = string.Format ("delete from categoria where id={0}", id);
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = deleteSql;

			dbCommand.ExecuteNonQuery ();
		}
	protected void OnRefreshActionActivated (object sender, EventArgs e)
	{
		listStore.Clear ();
		fillListStore ();

	}
	protected void OnAddActionActivated (object sender, EventArgs e)
	{
		string insertSql = string.Format(
			"insert into categoria (nombre) values ('{0}')",
			"Nuevo " + DateTime.Now
			);

		Console.WriteLine ("insertSql={0}", insertSql);
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = insertSql;

		dbCommand.ExecuteNonQuery ();
	}

	protected void OnEditActionActivated (object sender, EventArgs e)
	{
		TreeIter treeIter;
		treeView.Selection.GetSelected (out treeIter);
		object id = listStore.GetValue (treeIter, 0);
		ArticuloView articuloView = new ArticuloView (id);
	}

	//Metodos para categoria
	protected void OnAddAction1Activated (object sender, EventArgs e)
	{
		string insertSql = string.Format(
			"insert into categoria (nombre) values ('{0}')",
			"Nuevo " + DateTime.Now
			);

		Console.WriteLine ("insertSql={0}", insertSql);
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = insertSql;

		dbCommand.ExecuteNonQuery ();
	}



	protected void OnRefreshAction1Activated (object sender, EventArgs e)
	{
		listStore2.Clear ();
		fillListStore2 ();
	}

}

