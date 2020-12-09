namespace L5_ND
{
    /// <summary>
    /// a class to store basic information about a publication
    /// </summary>
    class Publication
    {
        public string Type {get; set;}
        public string Title {get; set;}
        public string Publisher {get; set;}
        public int ReleaseYear {get; set;}
        public int PageCount {get; set;}
        public int ReleaseCount {get; set;}
        
        public static bool operator > (Publication a, Publication b)
        {
            if (a.Type.CompareTo(b.Type) > 0)
            {
                return true;
            }
            else if (a.Type.CompareTo(b.Type) < 0)
            {
                return false;
            }
            else 
            {
                if (a.Title.CompareTo(b.Title) > 0)
                {
                    return true;
                }
                else if (a.Title.CompareTo(b.Title) < 0)
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }


        }

        public static bool operator < (Publication a, Publication b)
        {
            if (a.Type.CompareTo(b.Type) > 0)
            {
                return false;
            }
            else if (a.Type.CompareTo(b.Type) < 0)
            {
                return true;
            }
            else 
            {
                if (a.Title.CompareTo(b.Title) > 0)
                {
                    return false;
                }
                else if (a.Title.CompareTo(b.Title) < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
