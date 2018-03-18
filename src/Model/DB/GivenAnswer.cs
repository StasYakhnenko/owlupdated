namespace Model.DB
{
	public class GivenAnswer
    {
        public int Id { get; set; }
        public Answer Answer { get; set; }
        public int AnswerId { get; set; }
        public GivenQuestion Question { get; set; }
        public int QuestionId { get; set; }
    }
}
