import axios from 'axios'

class PersonalListService {
    url = 'http://localhost:5133/api/insurance';

    public async GetList(): Promise<InsuredItem[]> {
        try {
            const response = await axios.get(this.url)
            return response.data
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

export interface InsuredItem {
    id: number;
    name: string;
    value: number;
    catagory: catagories
}

export enum catagories {
    Electronics = 1,
    Clothing = 2,
    Kitchen = 3,
}