public interface Player {
	float getVelocity();
	void setVelocity(float velocity);
	int getHealth();
	void setHealth(int health);
	void attack(float x, float y);
}
