using System;
using Gtk;
using SerpisAd;
using System.Data;

public partial class MainWindow: Gtk.Window
	{	
	private IDbConnection dbConnection;
	private ListStore listStore;


	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		dbConnection = App.Instance.DbConnection;

		deleteAction.Sensitive = false;
		editAction.Sensitive = false;

		treeView.AppendColumn ("id", new CellRendererText (), "text", 0);
		treeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		treeView.AppendColumn ("precio", new CellRendererText (), "text", 2);

		listStore = new ListStore (typeof(ulong), typeof(string), typeof(ulong));
		treeView.Model = listStore;



		fillListStore ();
		treeView.Selection.Changed += selectionChanged;
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	private void fillListStore() {
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = "select * from categoria";

		IDataReader dataReader = dbCommand.ExecuteReader ();
		while (dataReader.Read()) {
			object id = dataReader ["id"];
			object nombre = dataReader ["nombre"];
			object precio = dataReader ["precio"];
			listStore.AppendValues (id, nombre,precio);
		}
		dataReader.Close ();
	}
	private void selectionChanged (object sender, EventArgs e) {
		Console.WriteLine ("selectionChanged");
		bool hasSelected = treeView.Selection.CountSelectedRows () > 0;
		deleteAction.Sensitive = hasSelected;
		editAction.Sensitive = hasSelected;
	}
}
