import axios from 'axios'

class PersonalListService {
    url = 'http://localhost:5133/api/Insurance';

    public async GetList(): Promise<TableData[]> {
        try {
            const response = await axios.get(this.url)
            const insuredItems = [];
            for (const id in CatagoryId) {
                console.log(id)
                const filteredData = response.data.filter((d) => d.catagoryId == id)
                insuredItems.push(
                    {
                        catagory: CatagoryNames[id],
                        body: filteredData
                    });
            }
            return insuredItems;

        } catch (e) {
            console.log(e)
            return [];
        }
    }

    public async PostItem(): Promise<number> {
        try {
            const response = await axios.post(this.url, {});
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
    catagoryId: CatagoryId
}

export enum CatagoryId {
    Electronics = 1,
    Clothing = 2,
    Kitchen = 3,
}
export const CatagoryNames = {
    1: 'Electronics',
    2: 'Clothing',
    3: 'Kitchen'
}