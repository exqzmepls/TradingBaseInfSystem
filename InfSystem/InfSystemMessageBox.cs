using System;
using System.Windows.Forms;

namespace InfSystem
{
    public abstract class InfSystemMessageBox
    {
        static internal void ShowError(Exception e)
        {
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static internal void ShowSuccessAdding()
        {
            MessageBox.Show("Запись успешно добавлена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static internal void ShowSuccessDeleting()
        {
            MessageBox.Show("Запись успешно удалена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static internal void ShowSuccessUpdating()
        {
            MessageBox.Show("Запись успешно изменена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static internal DialogResult ConfirmDeleting()
        {
            return MessageBox.Show("Удаление записи может вызвать УДАЛЕНИЕ ВСЕХ СВЯЗАННЫХ С НЕЙ ЗАПИСЕЙ!\nВы уверены, что хотите УДАЛИТЬ данную запись? ", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
