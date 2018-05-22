using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Enemy{
	int getHealth();
	void setHealth(int health);
	GameObject getHealthBar ();
	void attack();
	void attacking(bool b);
	int getDamage ();
	void setDamage(int damage);
}
