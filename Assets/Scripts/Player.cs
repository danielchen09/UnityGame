public interface Player {
	string getName ();
	float getVelocity();
	void setVelocity(float velocity);
	int getHealth();
	void setHealth(int health);
	int getEnergy ();
	void setEnergy(int energy);
	void incrementEnergy(int energy);
	void attack(float x, float y);
	int getDamage ();
	void setDamage (int damage);
	int getScore();
	void setScore (int score);
}
