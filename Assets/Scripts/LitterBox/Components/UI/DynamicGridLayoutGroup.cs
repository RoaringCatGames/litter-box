using System;
using UnityEngine;
using UnityEngine.UI;

public class DynamicGridLayoutGroup : MonoBehaviour {
  public bool shouldPreserveCellSize = false;

  [Tooltip("This should be the transform from the item that will resolve the size of your content area. For a 'Scroll View' component, this will be the 'ScrollView'")]
  public RectTransform targetRectTransform;

  void Start() {
    
    RectTransform rect = targetRectTransform;

    GridLayoutGroup glg = gameObject.GetComponent<GridLayoutGroup>();

    if (glg.constraint == GridLayoutGroup.Constraint.FixedColumnCount) {

      var usableWidth = rect.rect.width - (glg.padding.left + glg.padding.right);
      
      if (shouldPreserveCellSize) {
        
        var itemSizeWithSpacing = glg.cellSize.x + (glg.spacing.x/2);
        glg.constraintCount = Mathf.FloorToInt(usableWidth/itemSizeWithSpacing);

        var extraSpacing = usableWidth - (itemSizeWithSpacing * glg.constraintCount);
        var spacingAdditionPerItem = extraSpacing/glg.constraintCount;
        glg.spacing += new Vector2(spacingAdditionPerItem, spacingAdditionPerItem);

      } else {

        var itemSizeWithSpacing = usableWidth / glg.constraintCount;
        var cellSize = 0.9f * itemSizeWithSpacing;
        var spacing = 0.1f * itemSizeWithSpacing;
        glg.cellSize = new Vector2(cellSize, cellSize);
        glg.spacing = new Vector2(spacing, spacing);

      }
    }

    // This only works with Script Execution Order AFTER DefaultTime
    //  because the GridLayouGroup and Canvas size calculations have
    //  not run otherwise, and thus Transitioning to the Scene will
    //  not render the grid layout properly.
    transform.parent.gameObject.SetActive(false);
    transform.parent.gameObject.SetActive(true);
    
  }
}
