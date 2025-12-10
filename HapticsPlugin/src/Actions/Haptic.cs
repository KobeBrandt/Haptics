namespace Loupedeck.HapticsPlugin.Actions
{
    using System;

    public class Haptic : ActionEditorCommand
    {
        public Haptic()
        {
            // Set basic properties
            this.Name = "haptic";
            this.DisplayName = "Haptic";
            this.GroupName = "";
            this.Description = "Feel the Haptic";


            // Add controls for user configuration
            PluginLog.Info("Adding controls");

            this.ActionEditor.AddControlEx(
                new ActionEditorListbox(name: "haptic", labelText: "Select a haptic:"));

            PluginLog.Info("Added controls");

            // Subscribe to events
            this.ActionEditor.ListboxItemsRequested += OnListboxItemsRequested;

            this.ActionEditor.ControlValueChanged += this.OnControlValueChanged;
        }

        private static void OnListboxItemsRequested(Object sender, ActionEditorListboxItemsRequestedEventArgs e)
        {
            if (!e.ControlName.EqualsNoCase("haptic"))
            {
                return;
            }

            // Add items to the listbox
            // ─── State‑Change Waveforms ───────────────────────────────────────
            e.AddItem(
                name: "sharp_state_change",
                displayName: "Sharp State Change",
                description:
                "Short, high‑intensity pulse for discrete state transitions (button presses, toggles)");

            e.AddItem(
                name: "damp_state_change",
                displayName: "Damp State Change",
                description: "Gradual intensity change for smooth state transitions");

// ─── Collision Waveforms ───────────────────────────────────────────
            e.AddItem(
                name: "sharp_collision",
                displayName: "Sharp Collision",
                description: "High‑intensity impact simulation for collision events");

            e.AddItem(
                name: "damp_collision",
                displayName: "Damp Collision",
                description: "Medium‑intensity impact with gradual decay");

            e.AddItem(
                name: "subtle_collision",
                displayName: "Subtle Collision",
                description: "Low‑intensity feedback for light contact events");

// ─── Alert Waveforms ───────────────────────────────────────────────
            e.AddItem(
                name: "happy_alert",
                displayName: "Happy Alert",
                description: "Positive feedback pattern for success states");

            e.AddItem(
                name: "angry_alert",
                displayName: "Angry Alert",
                description: "Attention‑grabbing pattern for error conditions");

            e.AddItem(
                name: "completed",
                displayName: "Completed",
                description: "Confirmation pattern for task completion");

// ─── Special Waveforms ─────────────────────────────────────────────
            e.AddItem(
                name: "square",
                displayName: "Square",
                description: "Sharp‑edged waveform with defined start/stop points");

            e.AddItem(
                name: "wave",
                displayName: "Wave",
                description: "Smooth sinusoidal pattern with gradual transitions");

            e.AddItem(
                name: "firework",
                displayName: "Firework",
                description: "Multi‑burst pattern with varying intensities");

            e.AddItem(
                name: "mad",
                displayName: "Mad",
                description: "High‑frequency chaotic pattern");

            e.AddItem(
                name: "knock",
                displayName: "Knock",
                description: "Repetitive impact pattern");

            e.AddItem(
                name: "jingle",
                displayName: "Jingle",
                description: "Musical‑style pattern with multiple tones");

            e.AddItem(
                name: "ringing",
                displayName: "Ringing",
                description: "Continuous oscillating pattern");


            e.SetSelectedItemName("damp_state_change");
        }

        private void OnControlValueChanged(Object sender, ActionEditorControlValueChangedEventArgs e)
        {
            if (!e.ControlName.EqualsNoCase("haptic"))
            {
                return;
            }

            PluginLog.Info("Starting haptics: " + e.ActionEditorState.GetControlValue("haptic").Trim());
            this.Plugin.PluginEvents.RaiseEvent(e.ActionEditorState.GetControlValue("haptic").Trim());
            e.ActionEditorState.SetDisplayName($"Haptic:\n{e.ActionEditorState.GetControlValue("haptic").Trim()}");
            PluginLog.Info($"Haptic:\n{e.ActionEditorState.GetControlValue("haptic").Trim()}");
        }

        protected override Boolean OnLoad()
        {
// ─── State‑Change Waveforms ───────────────────────────────────────
            this.Plugin.PluginEvents.AddEvent(
                "sharp_state_change",
                "Sharp State Change",
                "Short, high‑intensity pulse for discrete state transitions (button presses, toggles)");

            this.Plugin.PluginEvents.AddEvent(
                "damp_state_change",
                "Damp State Change",
                "Gradual intensity change for smooth state transitions");

// ─── Collision Waveforms ───────────────────────────────────────────
            this.Plugin.PluginEvents.AddEvent(
                "sharp_collision",
                "Sharp Collision",
                "High‑intensity impact simulation for collision events");

            this.Plugin.PluginEvents.AddEvent(
                "damp_collision",
                "Damp Collision",
                "Medium‑intensity impact with gradual decay");

            this.Plugin.PluginEvents.AddEvent(
                "subtle_collision",
                "Subtle Collision",
                "Low‑intensity feedback for light contact events");

// ─── Alert Waveforms ───────────────────────────────────────────────
            this.Plugin.PluginEvents.AddEvent(
                "happy_alert",
                "Happy Alert",
                "Positive feedback pattern for success states");

            this.Plugin.PluginEvents.AddEvent(
                "angry_alert",
                "Angry Alert",
                "Attention‑grabbing pattern for error conditions");

            this.Plugin.PluginEvents.AddEvent(
                "completed",
                "Completed",
                "Confirmation pattern for task completion");

// ─── Special Waveforms ─────────────────────────────────────────────
            this.Plugin.PluginEvents.AddEvent(
                "square",
                "Square",
                "Sharp‑edged waveform with defined start/stop points");

            this.Plugin.PluginEvents.AddEvent(
                "wave",
                "Wave",
                "Smooth sinusoidal pattern with gradual transitions");

            this.Plugin.PluginEvents.AddEvent(
                "firework",
                "Firework",
                "Multi‑burst pattern with varying intensities");

            this.Plugin.PluginEvents.AddEvent(
                "mad",
                "Mad",
                "High‑frequency chaotic pattern");

            this.Plugin.PluginEvents.AddEvent(
                "knock",
                "Knock",
                "Repetitive impact pattern");

            this.Plugin.PluginEvents.AddEvent(
                "jingle",
                "Jingle",
                "Musical‑style pattern with multiple tones");

            this.Plugin.PluginEvents.AddEvent(
                "ringing",
                "Ringing",
                "Continuous oscillating pattern");
            return true;
        }

        protected override Boolean RunCommand(ActionEditorActionParameters actionParameters)
        {
            if (!actionParameters.TryGetString("haptic", out var selectedHaptic))
            {
                return false;
            }

            // Perform action with user's configured text
            this.Plugin.PluginEvents.RaiseEvent(selectedHaptic.Trim());
            return true;
        }
    }
}