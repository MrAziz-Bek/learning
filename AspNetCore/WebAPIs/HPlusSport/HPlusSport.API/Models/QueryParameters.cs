namespace HPlusSport.API.Models;

public class QueryParameters
{
    const int MAX_SIZE = 100;

    public int Page { get; set; } = 1;

    private int _size = 50;
    public int Size
    {
        get { return _size; }
        set { _size = Math.Min(MAX_SIZE, value); }
    }

    public string SortBy { get; set; } = "Id";

    private string _sortOrder = "asc";
    public string SortOrder
    {
        get { return _sortOrder; }
        set
        {
            if (value == "asc" || value == "desc")
            {
                _sortOrder = value;
            }
        }
    }
}