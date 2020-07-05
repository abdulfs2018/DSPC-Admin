import { SectionDTO } from './section.model';

export class GraveOwnerDTO {
    id: number;
    subId: string;
    graveReferenceCode: string;
    graveRow: number;
    graveDepth: number;
    graveSize: string;
    graveLocation: string;
    graveHeadStone: boolean;
    graveOwnerName: string;
    graveOwnerAddress: string;
    remarks: string;
    section: SectionDTO;
}
