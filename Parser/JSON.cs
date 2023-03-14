namespace Parser 
{
    class JSON
    {
        private object json;

        public JSON(object json)
        {
            this.json = json;
        }

        public string getJson()
        {
            return this.json.ToString();
            //return this.json;
        }
    }
}