One way to achieve that outcome is to inherit `DataGridView`, swap out the control in your Designer file with your new `DataGridViewEx` control, then change its default behavior, customizing it to do what you want which is **reselect the same cell in DGV after an edit**. 

***
Here's a first pass at a custom `DataGridViewEx` that I tested and seems to do the trick. Whether or not this is the _exact_ behavior you're looking for, this is how you can do it and these are the methods that have to do with row/column/cell/currentcell selection.

    class DataGridViewEx : DataGridView
    {
        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            _isChanging = true;
            base.OnCellValueChanged(e);
            BeginInvoke(new Action(() => _isChanging = false));
        }
        bool _isChanging = false;
        protected override void SetSelectedCellCore(int columnIndex, int rowIndex, bool selected)
        {
            if (_isChanging)
            {
                base.SetSelectedCellCore(CurrentCell.ColumnIndex, CurrentCell.RowIndex, selected);
            }
            else
            {
                base.SetSelectedCellCore(columnIndex, rowIndex, selected);
            }
        }
        protected override void SetSelectedColumnCore(int columnIndex, bool selected)
        {
            if (_isChanging)
            {
                base.SetSelectedColumnCore(CurrentCell.ColumnIndex, selected);
            }
            else
            {
                base.SetSelectedColumnCore(columnIndex, selected && !_isChanging);
            }
        }
        protected override void SetSelectedRowCore(int rowIndex, bool selected)
        {
            if (_isChanging)
            {
                base.SetSelectedRowCore(CurrentCell.RowIndex, selected);
            }
            else
            {
                base.SetSelectedRowCore(rowIndex, selected && !_isChanging);
            }
        }
        protected override bool SetCurrentCellAddressCore(int columnIndex, int rowIndex, bool setAnchorCellAddress, bool validateCurrentCell, bool throughMouseClick)
        {
            if (_isChanging)
            {
                return base.SetCurrentCellAddressCore(CurrentCell.ColumnIndex, CurrentCell.RowIndex, setAnchorCellAddress, validateCurrentCell, throughMouseClick);
            }
            else
            {
                return base.SetCurrentCellAddressCore(columnIndex, rowIndex, setAnchorCellAddress, validateCurrentCell, throughMouseClick);
            }
        }
    }

***
**Test**

I used this minimal code to test. Since the question *is* about cell selection and *isn't* about `DataTable` bindings I chose to make a very simple `DataSource` for the DGV for testing purposes.


    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dgvDaten.AllowUserToAddRows = false;

            dgvDaten.DataSource = Records;
            Records.Add(new Record());
            dgvDaten.Columns[nameof(Record.Guid)].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDaten.Columns[nameof(Record.Description)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Records.Clear();

            Records.Add(new Record { Description = "Apple" });
            Records.Add(new Record { Description = "Orange" });
            Records.Add(new Record { Description = "Grape" });
        }

        BindingList<Record> Records = new BindingList<Record>();
    }
    class Record
    {
        public string Guid { get; set; } = System.Guid.NewGuid().ToString().Substring(0, 15).ToUpper();
        public string Description { get; set; }
    }