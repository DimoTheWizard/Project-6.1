namespace Parser 
{
    class JSON
    {
        private object json;

        public JSON(object json)
        {
            this.json = json;
        }

        public object getJson()
        {
            return this.json;
        }
    }
}