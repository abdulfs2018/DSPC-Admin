using System;


namespace KAIS.Interactive.DSPC_EXPLORER.Infrastructure.Model
{
    public class Section
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime DateOpened { get; set; }
        public int GraveCount { get; set; }
    }
}
