import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.JTextField;

public class Driver {
	
	private static String playerName;
	private static Class playerClass;

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
		
		//Select New File or Saved File
		JPanel fileChoice = new JPanel();
		JButton newFile = new JButton("New Game");
		JButton savedFile = new JButton("Saved File");
		
		fileChoice.add(newFile);
		fileChoice.add(savedFile);
		
		//File Action Listener
		//TODO: Add the action listeners and think about the structure
		
		//Text box for player name.
		JPanel nameFieldPanel = new JPanel();
		JLabel nameFieldLabel = new JLabel("Enter Name (Max 20 characters): ");
		JTextField nameTextField = new JTextField(20);
		JButton nameSubmit = new JButton("Submit");
		JButton nameReset = new JButton("Reset");
		
		nameFieldPanel.add(nameTextField);
		nameFieldPanel.add(nameFieldLabel);
		nameFieldPanel.add(nameSubmit);
		nameFieldPanel.add(nameReset);
		
		//Submit and Reset Action Listeners.
		nameSubmit.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				playerName = nameTextField.getText();
			}
		}));
		
		nameReset.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				nameTextField.setText("");
			}
		}));
		
		//Combo box for Class options.
		JPanel chooseClassPanel = new JPanel();
		JLabel chooseClassLabel = new JLabel("Please select your desired class: ");
		
		String[] classOpts = {"Fighter", "Braver", "Swordsman", "Force", "Assassin"};
		JComboBox<String> classOptions = new JComboBox<>(classOpts);
		
		JButton selectClassButton = new JButton("Submit");
		
		chooseClassPanel.add(chooseClassLabel);
		chooseClassPanel.add(classOptions);
		chooseClassPanel.add(selectClassButton);
		
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
