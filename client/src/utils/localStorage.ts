
export default function storage(command: string, key: string, value?: string): string | null {
  if (value)
    return localStorage[command](key, value);

  return localStorage[command](key);
}