﻿

namespace ClassLibrary1.CivilizationDirectory;

public interface ICharacter
{
    public int OwnerId { get; set; }
    public int Life { get; set; }
    public  int AttackValue { get; set; }
    
     
    int Attack(ICharacter target); //en vez de void, necesitamos el valor para cuando utilizamos la interfaz y por eso usamos un int
    int RecieveAttack(int damage); //en vez de void, necesitamos el valor para cuando utilizamos la interfaz y por eso usamos un int
     
}
    