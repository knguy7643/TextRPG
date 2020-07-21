
public enum EnemyType {

	Skeleton, Zombie, Slime;
	
	@Override
	public String toString() {
		return this.name();
	}
	
	public int[] getStats() {
		if (this == EnemyType.Skeleton) {
			int[] arr= {15, 8, 5, 5};
			return arr;
		}
		else if (this == EnemyType.Slime) {
			int[] arr= {10, 10, 5, 5};
			return arr;
		}
		else {
			int[] arr= {20, 15, 5, 5};
			return arr;
		}
	}
	
}
