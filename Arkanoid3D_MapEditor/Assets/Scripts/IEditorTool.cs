using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEditorTool
{
    Tool GetCurrentTool();
    bool IsActive();
}
