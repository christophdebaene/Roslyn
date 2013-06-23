public void SomeMethod()
{
   this.Click += (s, e) =>
   {
      MessageBox.Show(((MouseEventArgs)e).Location.ToString());
   }
   ;
   treeView.AfterExpand += new TreeViewEventHandler(delegate (object o, TreeViewEventArgs t)
   {
      t.Node.ImageIndex = (int)FolderIconEnum.open;
      t.Node.SelectedImageIndex = (int)FolderIconEnum.open;
   }
);
}