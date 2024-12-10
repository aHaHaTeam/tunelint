package org.goalteam.tunelint.view.toolbar

import androidx.compose.foundation.shape.CutCornerShape
import androidx.compose.material.Button
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.unit.dp
import org.goalteam.tunelint.model.changerequest.Notifiable
import org.goalteam.tunelint.model.core.PrimaryNoteValue
import org.goalteam.tunelint.viewmodel.RedactorScreenViewModel

@Composable
fun NoteTypesButtons(vm: RedactorScreenViewModel) {
    data class Value(
        val log: Int,
        val text: String,
    )

    val options =
        listOf(
            Value(-4, "Sixteenth"),
            Value(-3, "Eighth"),
            Value(-2, "Quarter"),
            Value(-1, "Half"),
            Value(0, "Whole"),
            Value(1, "Double"),
        )

    var currentOrder: Int by remember { mutableStateOf(-2) }
    val orderListener =
        object : Notifiable<Boolean> {
            override fun notify(notification: Boolean): Boolean {
                currentOrder = vm.interactor.getValue().order()
                return true
            }
        }
    vm.interactor.subscribe(orderListener)

    options.forEach { option ->
        Button(
            onClick = {
                vm.interactor.setValue(PrimaryNoteValue(option.log))
                println(vm.interactor.getValue().order())
            },
            enabled = currentOrder != option.log,
            colors = editButtonColors(),
            elevation = editButtonElevation(),
            shape = CutCornerShape(0.dp),
        ) {
            NoteIcon(option.log)
        }
    }
}
