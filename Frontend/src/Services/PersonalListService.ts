import axios from 'axios'

class PersonalListService {
    url = 'http://localhost:5133/api/Insurance';

    public async GetList(): Promise<TableData[]> {
        try {
            const response = await axios.get(this.url)
            const tableData: TableData[] = [];

            CatagoryIds.forEach((catagory) => {
                const filteredData = response.data.filter((d: InsuredItem) => d.catagoryId == catagory.id)
                tableData.push(
                    {
                        catagory: catagory.title,
                        body: filteredData
                    });
            });
            return tableData;

        } catch (e) {
            console.log(e)
            return [];
        }
    }

    public async PostItem(newItem: InsuredItem): Promise<number> {
        try {
            const response = await axios.post(this.url, newItem);
            return response.data;
        } catch (e) {
            console.log(e)
            return 0;
        }
    }

    public async DeleteItem(id: number): Promise<boolean> {
        try {
            const response = await axios.delete(`${this.url}/${id}`);
            return response.data;
        } catch (e) {
            console.log(e)
            return false;
        }
    }
}

export default new PersonalListService();

export interface TableData {
    catagory: string,
    body: InsuredItem[]
}

export interface InsuredItem {
    id: number;
    name: string;
    value: number;
    catagoryId: number;
}

export const CatagoryIds = [
    { id: 1, title: 'Electronics' },
    { id: 1, title: 'Clothing' },
    { id: 1, title: 'Kitchen' },
] 