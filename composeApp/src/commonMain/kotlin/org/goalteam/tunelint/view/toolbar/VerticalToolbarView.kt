package org.goalteam.tunelint.view.toolbar

import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.padding
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.DpOffset
import androidx.compose.ui.unit.dp
import org.goalteam.tunelint.viewmodel.RedactorScreenViewModel

@Composable
fun VerticalToolbarView(vm: RedactorScreenViewModel) {
    val padding = 4.dp
    val smallPadding = 0.dp
    val buttonDiameter = 40.dp
    val iconSize = 24.dp
    val tipOffset = DpOffset(16.dp, -(8.dp))
    val tipDelay = 750

    Column(modifier = Modifier.padding(padding)) {
        Column(modifier = Modifier.padding(0.dp, padding)) {
            undoRedoButtons(vm, buttonDiameter, smallPadding, iconSize, tipOffset, tipDelay)
        }
        Column(modifier = Modifier.padding(0.dp, padding)) {
            ModeButtons(vm, buttonDiameter, smallPadding, iconSize, tipOffset, tipDelay)
        }
    }
}
