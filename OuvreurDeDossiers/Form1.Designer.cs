﻿namespace OuvreurDeDossiers
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonOuvrir = new System.Windows.Forms.Button();
            this.comboChoixDossier = new System.Windows.Forms.ComboBox();
            this.buttonEditerDossiers = new System.Windows.Forms.Button();
            this.groupExecution = new System.Windows.Forms.GroupBox();
            this.buttonAjouterDossier = new System.Windows.Forms.Button();
            this.buttonEffaceDossier = new System.Windows.Forms.Button();
            this.groupAjout = new System.Windows.Forms.GroupBox();
            this.textBoxAjouter = new System.Windows.Forms.TextBox();
            this.buttonAjouter = new System.Windows.Forms.Button();
            this.groupModifier = new System.Windows.Forms.GroupBox();
            this.textBoxModifier = new System.Windows.Forms.TextBox();
            this.buttonModifier = new System.Windows.Forms.Button();
            this.groupSupprimer = new System.Windows.Forms.GroupBox();
            this.textBoxSupprimer = new System.Windows.Forms.TextBox();
            this.buttonSupprimer = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelTips = new System.Windows.Forms.Label();
            this.groupExecution.SuspendLayout();
            this.groupAjout.SuspendLayout();
            this.groupModifier.SuspendLayout();
            this.groupSupprimer.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOuvrir
            // 
            this.buttonOuvrir.Location = new System.Drawing.Point(655, 19);
            this.buttonOuvrir.Name = "buttonOuvrir";
            this.buttonOuvrir.Size = new System.Drawing.Size(101, 23);
            this.buttonOuvrir.TabIndex = 1;
            this.buttonOuvrir.Text = "Ouvrir le dossier";
            this.buttonOuvrir.UseVisualStyleBackColor = true;
            // 
            // comboChoixDossier
            // 
            this.comboChoixDossier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboChoixDossier.FormattingEnabled = true;
            this.comboChoixDossier.Location = new System.Drawing.Point(97, 18);
            this.comboChoixDossier.Name = "comboChoixDossier";
            this.comboChoixDossier.Size = new System.Drawing.Size(552, 28);
            this.comboChoixDossier.TabIndex = 0;
            this.comboChoixDossier.Text = " >> Choix des dossiers a ouvrir...";
            this.comboChoixDossier.SelectedIndexChanged += new System.EventHandler(this.comboChoixDossier_SelectedIndexChanged);
            // 
            // buttonEditerDossiers
            // 
            this.buttonEditerDossiers.Location = new System.Drawing.Point(39, 19);
            this.buttonEditerDossiers.Name = "buttonEditerDossiers";
            this.buttonEditerDossiers.Size = new System.Drawing.Size(23, 23);
            this.buttonEditerDossiers.TabIndex = 3;
            this.buttonEditerDossiers.Text = "U";
            this.toolTip1.SetToolTip(this.buttonEditerDossiers, "Modifier ce dossier ");
            this.buttonEditerDossiers.UseVisualStyleBackColor = true;
            this.buttonEditerDossiers.Click += new System.EventHandler(this.ButtonEditerDossiers_Click);
            // 
            // groupExecution
            // 
            this.groupExecution.Controls.Add(this.buttonAjouterDossier);
            this.groupExecution.Controls.Add(this.buttonEffaceDossier);
            this.groupExecution.Controls.Add(this.comboChoixDossier);
            this.groupExecution.Controls.Add(this.buttonEditerDossiers);
            this.groupExecution.Controls.Add(this.buttonOuvrir);
            this.groupExecution.Location = new System.Drawing.Point(10, 10);
            this.groupExecution.Name = "groupExecution";
            this.groupExecution.Size = new System.Drawing.Size(762, 58);
            this.groupExecution.TabIndex = 3;
            this.groupExecution.TabStop = false;
            this.groupExecution.Text = "Selection du dossier";
            // 
            // buttonAjouterDossier
            // 
            this.buttonAjouterDossier.Location = new System.Drawing.Point(10, 19);
            this.buttonAjouterDossier.Name = "buttonAjouterDossier";
            this.buttonAjouterDossier.Size = new System.Drawing.Size(23, 23);
            this.buttonAjouterDossier.TabIndex = 2;
            this.buttonAjouterDossier.Text = "C";
            this.toolTip1.SetToolTip(this.buttonAjouterDossier, "Ajouter un dossier a ouvrir");
            this.buttonAjouterDossier.UseVisualStyleBackColor = true;
            this.buttonAjouterDossier.Click += new System.EventHandler(this.buttonAjouterDossier_Click);
            // 
            // buttonEffaceDossier
            // 
            this.buttonEffaceDossier.Location = new System.Drawing.Point(68, 19);
            this.buttonEffaceDossier.Name = "buttonEffaceDossier";
            this.buttonEffaceDossier.Size = new System.Drawing.Size(23, 23);
            this.buttonEffaceDossier.TabIndex = 4;
            this.buttonEffaceDossier.Text = "D";
            this.toolTip1.SetToolTip(this.buttonEffaceDossier, "Supprimer ce dossier");
            this.buttonEffaceDossier.UseVisualStyleBackColor = true;
            this.buttonEffaceDossier.Click += new System.EventHandler(this.buttonEffaceDossier_Click);
            // 
            // groupAjout
            // 
            this.groupAjout.Controls.Add(this.textBoxAjouter);
            this.groupAjout.Controls.Add(this.buttonAjouter);
            this.groupAjout.Location = new System.Drawing.Point(10, 169);
            this.groupAjout.Name = "groupAjout";
            this.groupAjout.Size = new System.Drawing.Size(762, 58);
            this.groupAjout.TabIndex = 4;
            this.groupAjout.TabStop = false;
            this.groupAjout.Text = "Ajouter dossier";
            // 
            // textBoxAjouter
            // 
            this.textBoxAjouter.Location = new System.Drawing.Point(10, 21);
            this.textBoxAjouter.Name = "textBoxAjouter";
            this.textBoxAjouter.Size = new System.Drawing.Size(639, 20);
            this.textBoxAjouter.TabIndex = 4;
            // 
            // buttonAjouter
            // 
            this.buttonAjouter.Location = new System.Drawing.Point(655, 19);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(101, 23);
            this.buttonAjouter.TabIndex = 3;
            this.buttonAjouter.Text = "Ajouter dossier";
            this.buttonAjouter.UseVisualStyleBackColor = true;
            this.buttonAjouter.Click += new System.EventHandler(this.buttonAjouter_Click);
            // 
            // groupModifier
            // 
            this.groupModifier.Controls.Add(this.textBoxModifier);
            this.groupModifier.Controls.Add(this.buttonModifier);
            this.groupModifier.Location = new System.Drawing.Point(10, 233);
            this.groupModifier.Name = "groupModifier";
            this.groupModifier.Size = new System.Drawing.Size(762, 58);
            this.groupModifier.TabIndex = 5;
            this.groupModifier.TabStop = false;
            this.groupModifier.Text = "Modifier dossier";
            // 
            // textBoxModifier
            // 
            this.textBoxModifier.Location = new System.Drawing.Point(10, 21);
            this.textBoxModifier.Name = "textBoxModifier";
            this.textBoxModifier.Size = new System.Drawing.Size(639, 20);
            this.textBoxModifier.TabIndex = 4;
            // 
            // buttonModifier
            // 
            this.buttonModifier.Location = new System.Drawing.Point(655, 19);
            this.buttonModifier.Name = "buttonModifier";
            this.buttonModifier.Size = new System.Drawing.Size(101, 23);
            this.buttonModifier.TabIndex = 3;
            this.buttonModifier.Text = "Modifier dossier";
            this.buttonModifier.UseVisualStyleBackColor = true;
            this.buttonModifier.Click += new System.EventHandler(this.buttonModifier_Click);
            // 
            // groupSupprimer
            // 
            this.groupSupprimer.Controls.Add(this.textBoxSupprimer);
            this.groupSupprimer.Controls.Add(this.buttonSupprimer);
            this.groupSupprimer.Location = new System.Drawing.Point(10, 297);
            this.groupSupprimer.Name = "groupSupprimer";
            this.groupSupprimer.Size = new System.Drawing.Size(762, 58);
            this.groupSupprimer.TabIndex = 6;
            this.groupSupprimer.TabStop = false;
            this.groupSupprimer.Text = "Supprimer dossier";
            // 
            // textBoxSupprimer
            // 
            this.textBoxSupprimer.Location = new System.Drawing.Point(10, 21);
            this.textBoxSupprimer.Name = "textBoxSupprimer";
            this.textBoxSupprimer.Size = new System.Drawing.Size(639, 20);
            this.textBoxSupprimer.TabIndex = 4;
            // 
            // buttonSupprimer
            // 
            this.buttonSupprimer.BackColor = System.Drawing.Color.Crimson;
            this.buttonSupprimer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSupprimer.Location = new System.Drawing.Point(655, 19);
            this.buttonSupprimer.Name = "buttonSupprimer";
            this.buttonSupprimer.Size = new System.Drawing.Size(101, 23);
            this.buttonSupprimer.TabIndex = 3;
            this.buttonSupprimer.Text = "Supprimer dossier";
            this.buttonSupprimer.UseVisualStyleBackColor = false;
            this.buttonSupprimer.Click += new System.EventHandler(this.buttonSupprimer_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 300;
            this.toolTip1.ReshowDelay = 100;
            // 
            // labelTips
            // 
            this.labelTips.AutoSize = true;
            this.labelTips.Location = new System.Drawing.Point(668, 94);
            this.labelTips.Name = "labelTips";
            this.labelTips.Size = new System.Drawing.Size(35, 13);
            this.labelTips.TabIndex = 7;
            this.labelTips.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::OuvreurDeDossiers.Properties.Resources.fond;
            this.ClientSize = new System.Drawing.Size(782, 116);
            this.Controls.Add(this.labelTips);
            this.Controls.Add(this.groupSupprimer);
            this.Controls.Add(this.groupModifier);
            this.Controls.Add(this.groupAjout);
            this.Controls.Add(this.groupExecution);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lanceur de dossiers";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.groupExecution.ResumeLayout(false);
            this.groupAjout.ResumeLayout(false);
            this.groupAjout.PerformLayout();
            this.groupModifier.ResumeLayout(false);
            this.groupModifier.PerformLayout();
            this.groupSupprimer.ResumeLayout(false);
            this.groupSupprimer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOuvrir;
        private System.Windows.Forms.ComboBox comboChoixDossier;
        private System.Windows.Forms.Button buttonEditerDossiers;
        private System.Windows.Forms.GroupBox groupExecution;
        private System.Windows.Forms.Button buttonAjouterDossier;
        private System.Windows.Forms.Button buttonEffaceDossier;
        private System.Windows.Forms.GroupBox groupAjout;
        private System.Windows.Forms.TextBox textBoxAjouter;
        private System.Windows.Forms.Button buttonAjouter;
        private System.Windows.Forms.GroupBox groupModifier;
        private System.Windows.Forms.TextBox textBoxModifier;
        private System.Windows.Forms.Button buttonModifier;
        private System.Windows.Forms.GroupBox groupSupprimer;
        private System.Windows.Forms.TextBox textBoxSupprimer;
        private System.Windows.Forms.Button buttonSupprimer;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelTips;
    }
}

