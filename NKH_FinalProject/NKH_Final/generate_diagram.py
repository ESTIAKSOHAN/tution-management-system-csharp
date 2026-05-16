import matplotlib.pyplot as plt
import matplotlib.patches as mpatches
from matplotlib.patches import FancyBboxPatch, FancyArrowPatch
import matplotlib.lines as mlines

fig, ax = plt.subplots(1, 1, figsize=(16, 12))
ax.set_xlim(0, 10)
ax.set_ylim(0, 10)
ax.axis('off')

# Define colors
box_color = '#E8E8E8'
modal_color = '#F0F0F0'
text_color = '#000000'

# Helper function to draw boxes
def draw_box(ax, x, y, width, height, label, is_modal=False):
	color = modal_color if is_modal else box_color
	box = FancyBboxPatch((x - width/2, y - height/2), width, height,
						  boxstyle="round,pad=0.1", 
						  edgecolor='black', facecolor=color, linewidth=2)
	ax.add_patch(box)
	ax.text(x, y, label, ha='center', va='center', fontsize=9, weight='bold')

# Helper function to draw arrows
def draw_arrow(ax, x1, y1, x2, y2, label='', curve=0):
	if curve == 0:
		arrow = FancyArrowPatch((x1, y1), (x2, y2),
							   arrowstyle='->', mutation_scale=20, 
							   linewidth=1.5, color='black')
	else:
		arrow = FancyArrowPatch((x1, y1), (x2, y2),
							   arrowstyle='->', mutation_scale=20,
							   connectionstyle=f"arc3,rad={curve}",
							   linewidth=1.5, color='black')
	ax.add_patch(arrow)
	if label:
		mid_x, mid_y = (x1 + x2) / 2, (y1 + y2) / 2
		ax.text(mid_x + 0.3, mid_y + 0.2, label, fontsize=8, 
				bbox=dict(boxstyle='round', facecolor='white', alpha=0.8))

# Draw screens
# Login/Overview screens (right side)
draw_box(ax, 8.5, 8, 1.2, 1.5, 'Login')
draw_box(ax, 8.5, 6, 1.2, 1.5, 'Overview')

# Details screen (top right)
draw_box(ax, 5.5, 9, 1.5, 2, 'Details\nScreen', False)

# Confirmation modal (bottom)
draw_box(ax, 5, 3.5, 2, 1.2, 'Confirmation\n(Modal)', True)

# Home Screen (left side)
draw_box(ax, 1.5, 7, 1.8, 1.8, 'Home Screen\n(Logged In)', False)

# Await Logout Screen (bottom right)
draw_box(ax, 5.5, 1.5, 2, 1.5, 'Await Logout\nScreen', False)

# Add loading indicator
ax.add_patch(mpatches.Circle((6.2, 2), 0.3, color='white', ec='black', linewidth=1.5))
ax.text(6.2, 2, '...', ha='center', va='center', fontsize=8)

# Draw arrows with labels
# Login to Details [Push]
draw_arrow(ax, 7.8, 8.2, 6.5, 9.2, '[Push]')

# Overview to Home [Push]
draw_arrow(ax, 7.8, 6, 2.8, 6.5, '[Push]', curve=0.2)

# Home to Confirmation [Modal]
draw_arrow(ax, 1.5, 6, 4, 4.2, '[Modal]', curve=-0.3)

# Confirmation No back to Home [Dismiss modal]
draw_arrow(ax, 4, 3.8, 2.2, 6.5, '[Dismiss modal]', curve=-0.3)

# Confirmation Yes to Await Logout [Push]
draw_arrow(ax, 5.8, 2.9, 5.5, 2.5, '[Push]')

# Details back to Overview [Cancel & Pop]
draw_arrow(ax, 5.5, 8.2, 2.8, 6.8, '[Cancel & Pop]', curve=0.5)

# Details [Pop] back
draw_arrow(ax, 6.5, 9.5, 8, 8.7, '[Pop]', curve=0.3)

# Await Logout Success to Overview [Reset]
draw_arrow(ax, 6.5, 1.5, 8.5, 5.2, '[Reset]', curve=0.4)

# Add title
ax.text(5, 9.7, 'Navigation Flow Diagram - Login/Logout System', 
		fontsize=14, weight='bold', ha='center')

# Add a legend-like note
ax.text(0.5, 0.3, '• [Push] - Navigate to new screen\n• [Pop] - Return to previous screen\n• [Modal] - Show modal overlay\n• [Reset] - Clear stack and navigate', 
		fontsize=8, verticalalignment='bottom',
		bbox=dict(boxstyle='round', facecolor='lightyellow', alpha=0.8))

plt.tight_layout()
plt.savefig('E:\\NKH_FinalProject\\NKH_Final\\ED_Navigation_Diagram.jpg', dpi=300, bbox_inches='tight')
print("Diagram created successfully: ED_Navigation_Diagram.jpg")
plt.close()
