import axios from 'axios'

class PersonalListService {
    // Update API's url
    url = 'http://localhost:5133/api/Insurance';

    /**
     * Gets the list of insured items
     * @returns Array of table data, or an empty array if unsuccessful
     */
    public async GetList(): Promise<TableData[]> {
        try {
            const response = await axios.get(this.url)
            const tableData: TableData[] = [];

            CategoryIds.forEach((category) => {
                const filteredData = response.data.filter((d: InsuredItem) => d.categoryId == category.id)
                tableData.push(
                    {
                        category: category.title,
                        body: filteredData
                    });
            });
            return tableData;

        } catch (e) {
            console.log(e)
            return [];
        }
    }

    /**
     * Request that a new item is created
     * @param newItem item to create
     * @returns Id of a newly created item, or 0 if unsuccessful
     */
    public async PostItem(newItem: InsuredItem): Promise<number> {
        try {
            const response = await axios.post(this.url, newItem);
            return response.data;
        } catch (e) {
            console.log(e)
            return 0;
        }
    }

    /**
     * Request that an existing item is deleted
     * @param id unique id of item to delete
     * @returns true if successful, otherwise false
     */
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
    category: string,
    body: InsuredItem[]
}

export interface InsuredItem {
    id: number;
    name: string;
    value: number;
    categoryId: number;
}

export const CategoryIds = [
    { id: 1, title: 'Electronics' },
    { id: 1, title: 'Clothing' },
    { id: 1, title: 'Kitchen' },
] 