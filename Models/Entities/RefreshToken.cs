namespace testSibers.Models.Entities;

//Сущность refreshtoken 
public class RefreshToken
{
    //ID токена
    public Guid Id { get; private set; }
    
    //Владелец токена
    public User Owner { get; private set; }
    
    //Время создания токена
    public DateTime IssuedAt { get; private set; }
    
    //Время истечения срока токена
    public DateTime ValidUntil { get; private set; }
    
}