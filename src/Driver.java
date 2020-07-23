import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;

public class Driver {

	public static void main(String[] args) {
	
		//Initialize GUI Here When Ready
		JFrame frame = new JFrame("Xevoria - Simple Text RPG");
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		//Keep size consistent. Change dimensions if needed.
		frame.setResizable(false);
		frame.setSize(700, 400);
		
		//Area to publish text.
		JTextArea system = new JTextArea();
		system.setEditable(false);
		system.setLineWrap(true);
		system.setWrapStyleWord(true);
		
		//Auto scroll on the text area.
		JScrollPane vertical = new JScrollPane(system);
		vertical.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_ALWAYS);
		system.setCaretPosition(system.getDocument().getLength());
		
		//Text box for player name.
		JPanel nameFieldPanel = new JPanel();
		
		
		
		//Combo box for Class options.
		
	}
	
	public static void battle(JTextArea system, Player player, Enemy enemy) {
		//Work on parameters.
		
		if (player.getAgility() >= enemy.getAgility()) {
			while ((player.getHP() != 0) || (enemy.getHP() != 0)) {
				
			}
			if (player.getHP() == 0) {
				//System "You have die."
			}
			else {
				//System "You have slain..."
				//Gain exp
			}
		}
		else {
			
		}
		
	}
	
}
