namespace Parser 
{
    class MT940 
    {
        private string filePath;
        // private List<string> filePaths = new List<string>;
        public MT940(string filePath)
        {
            this.filePath = filePath;
        }

        public string getMT940() 
        {
            return this.filePath;
        }
    }
}