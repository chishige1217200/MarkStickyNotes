namespace MarkStickyNotes
{
    public partial class ListForm : Form
    {
        public ListForm()
        {
            InitializeComponent();
        }

        public void setCategories()
        {
            //var categories = ContentManager.GetCategories();
            this.categoriesListBox.Items.Clear();
            //this.categoriesListBox.Items.AddRange(categories);
        }
    }
}
