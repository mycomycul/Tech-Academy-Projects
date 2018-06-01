// Initial Table design was having entities that just stored if the entity was Flagged.
// A new Code First table was added so that entities could have a one to many relationship 
//with Flags

namespace Project.Models{

    [Table("Flag")]
    public class Flag
    {
        public int FlagID { get; set; }             
        public FlagOption FlagStatus { get; set; }  //What kind of Flag is it
        public User UserFlagging { get; set; }      //Who Flagged it
        public virtual Post Post { get; set; }      //Tables related to flag table
    }
    
    //Enumeration for Flags
    public enum FlagOption
    {
        Offensive = 1,
        Spam,
        NonOriginalContent,
        Misinformation
    }

    //Sample Table that needs flag relationship
    [Table("Post")]
    public class Post
    {
        /* ...Table Properties...*/

        //navigation Property for flag table relationship
        public virtual ICollection<Flag> Flags { get; set; }
    
    }  
}
    
