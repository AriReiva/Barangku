using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barangku.Model.ViewModel;
using Barangku.Service.Interface;
using Barangku.Model.Common;

namespace Barangku.State
{
    public class TransaksiState
    {
        public List<AddDetailTransaksiVM> Items { get; set; } = new();

        public decimal Total => Items.Sum(i => i.Subtotal);

        public void AddItem(AddDetailTransaksiVM item)
        {
            var existing = Items.FirstOrDefault(i => i.ProdukId == item.ProdukId);
            if (existing != null)
            {
                existing.Jumlah += item.Jumlah;
                existing.Subtotal = existing.Jumlah * existing.Harga;
            }
            else
            {
                item.Subtotal = item.Jumlah * item.Harga;
                Items.Add(item);
            }
        }

        public void RemoveItem(int produkId)
        {
            Items.RemoveAll(i => i.ProdukId == produkId);
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}
